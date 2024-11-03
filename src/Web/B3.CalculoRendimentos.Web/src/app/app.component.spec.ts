import {TestBed, ComponentFixture} from '@angular/core/testing';
import {AppComponent} from './app.component';
import {AppService} from './app.service';
import {HttpClientTestingModule} from '@angular/common/http/testing';
import {of, throwError} from 'rxjs';
import {HttpErrorResponse} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let appService: AppService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule, FormsModule],
      providers: [AppService]
    }).compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    appService = TestBed.inject(AppService);
  });

  it('deve retornar mensagem de erro se valorInicial for menor ou igual a zero', () => {
    component.valorInicial = 0;
    component.prazoMeses = 10;
    const errors = component['validateInputs']();
    expect(errors).toContain('Erro: O valor inicial deve ser maior que zero.');
  });

  it('deve retornar mensagem de erro se prazoMeses for menor ou igual a um', () => {
    component.valorInicial = 1000;
    component.prazoMeses = 1;
    const errors = component['validateInputs']();
    expect(errors).toContain('Erro: O prazo em meses deve ser maior que um.');
  });

  it('deve retornar ambas as mensagens de erro se valorInicial e prazoMeses forem inválidos', () => {
    component.valorInicial = 0;
    component.prazoMeses = 1;
    const errors = component['validateInputs']();
    expect(errors).toContain('Erro: O valor inicial deve ser maior que zero.');
    expect(errors).toContain('Erro: O prazo em meses deve ser maior que um.');
  });

  it('deve definir errorMessage corretamente em caso de erro 400', () => {
    const httpError = new HttpErrorResponse({
      status: 400,
      error: 'Mensagem de erro do servidor'
    });

    component['handleError'](httpError);
    expect(component.errorMessage).toBe('Erro: Mensagem de erro do servidor');
  });

  it('deve definir errorMessage para erro genérico se a resposta do servidor não for uma string', () => {
    const httpError = new HttpErrorResponse({
      status: 500,
      error: { message: 'Erro interno' }
    });

    component['handleError'](httpError);
    expect(component.errorMessage).toBe('Erro ao calcular o CDB. Tente novamente mais tarde.');
  });

  it('deve chamar o serviço se os dados de entrada forem válidos', () => {
    spyOn(appService, 'calcularRendimento').and.returnValue(of({ rendimentoBruto: 1000, rendimentoLiquido: 900 }));
    component.valorInicial = 1000;
    component.prazoMeses = 12;

    component.submitForm();

    expect(appService.calcularRendimento).toHaveBeenCalledWith(1000, 12);
    expect(component.rendimentoBruto).toBe(1000);
    expect(component.rendimentoLiquido).toBe(900);
    expect(component.errorMessage).toBeNull();
  });

  it('deve definir errorMessage se o serviço retornar um erro', () => {
    spyOn(appService, 'calcularRendimento').and.returnValue(throwError(() => new HttpErrorResponse({
      status: 400,
      error: 'Erro simulado do servidor'
    })));

    component.valorInicial = 1000;
    component.prazoMeses = 12;
    component.submitForm();

    expect(component.errorMessage).toBe('Erro: Erro simulado do servidor');
    expect(component.rendimentoBruto).toBeNull();
    expect(component.rendimentoLiquido).toBeNull();
  });
});

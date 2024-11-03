import {Component} from '@angular/core';
import {AppService} from "./app.service";
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  valorInicial: number = 0;
  prazoMeses: number = 0;
  rendimentoBruto: number | null = null;
  rendimentoLiquido: number | null = null;
  errorMessage: string | null = null;

  constructor(private appService: AppService) {
  }

  submitForm() {
    const errors = this.validateInputs();

    if (errors.length > 0) {
      this.errorMessage = errors.join(' ');
      this.rendimentoBruto = null;
      this.rendimentoLiquido = null;
      return;
    }

    this.appService.calcularRendimento(this.valorInicial, this.prazoMeses)
      .subscribe({
        next: (data) => {
          this.rendimentoBruto = data.rendimentoBruto;
          this.rendimentoLiquido = data.rendimentoLiquido;
          this.errorMessage = null;
        },
        error: (err: HttpErrorResponse) => this.handleError(err)
      });
  }

  private validateInputs(): string[] {
    const errorMessages: string[] = [];

    if (this.valorInicial <= 0) {
      errorMessages.push('Erro: O valor inicial deve ser maior que zero.');
    }
    if (this.prazoMeses <= 1) {
      errorMessages.push('Erro: O prazo em meses deve ser maior que um.');
    }

    return errorMessages;
  }

  private handleError(err: HttpErrorResponse) {
    if (err.status === 400 && typeof err.error === 'string') {
      this.errorMessage = `Erro: ${err.error}`;
    } else {
      this.errorMessage = 'Erro ao calcular o CDB. Tente novamente mais tarde.';
    }
    this.rendimentoBruto = null;
    this.rendimentoLiquido = null;
    console.error(err);
  }
}

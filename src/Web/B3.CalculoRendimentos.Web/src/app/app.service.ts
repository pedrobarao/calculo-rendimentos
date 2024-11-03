import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AppService {
    private apiUrl = 'http://localhost:5240/api/rendimentos';

    constructor(private http: HttpClient) {
    }

    calcularRendimento(valorInicial: number, prazoMeses: number): Observable<{
        rendimentoBruto: number,
        rendimentoLiquido: number
    }> {
        return this.http.post<{ rendimentoBruto: number, rendimentoLiquido: number }>(this.apiUrl, {
            valorInicial,
            prazoMeses
        });
    }
}

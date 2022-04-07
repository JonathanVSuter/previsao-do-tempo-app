import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Result } from './Dtos/Result';
import { RootObject } from './Dtos/RootObject';

@Injectable()
export class BuscarDadosCidadeService 
{    
    private urlPrevisaoDoTempoCidades:string = "https://localhost:44335/previsaodotempo/";
    
    constructor(private http: HttpClient) 
    { 
        
    }
    // BuscarDadosCidades(): void {
    //     var resultado = this.http.get("https://localhost:44335/previsaodotempo/BuscarDadosCidade?cidadeNome=Bal").toPromise();
    // }
    async BuscarDadosCidades(handler: HandlerFunction): Promise<RootObject>
    {
        try {
            const res_1 = await fetch('http://localhost:8080/dados');
            const res_2 = handler(res_1);
            const dados = await res_2.json();
            return dados.map(dado => new (dado.cidade, dado.uf, dado.id));
        } catch (err) {
            console.log(err);
            throw new Error('Não foi possível importar as negociações');
        }
    }

}
export interface HandlerFunction
{
    (res: Response):Response;
}
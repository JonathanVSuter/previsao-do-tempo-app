import { Injectable } from "@angular/core";
import { BuscarDadosCidadeService } from "../services/BuscarDadosCidadeService";

@Injectable()
export class LocalizarCidadeViewModel
{     
    constructor(private _servicoBuscarDadosClima:BuscarDadosCidadeService)
    {        
    }
    public async BuscarDadosCidades()
    {
        const res = await this._servicoBuscarDadosClima.BuscarDadosCidades(res=>
            {
                if(res.ok)
                {
                    return res;
                }
                else
                {
                    throw new Error(res.statusText);
                }
            });
    }
}

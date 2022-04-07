import { Component, OnInit } from '@angular/core';
import { Cidade } from 'src/app/models/Cidade';
import { List } from 'src/app/utils/List';
import{LocalizarCidadeViewModel} from 'src/app/viewModels/LocalizarCidadeViewModel';

@Component({
  selector: 'app-localizar-cidade',
  templateUrl: './localizar-cidade.component.html',
  styleUrls: ['./localizar-cidade.component.css']
})
export class LocalizarCidadeComponent implements OnInit {
  
  //_context:LocalizarCidadeViewModel;
  item?: Cidade;
  items: List<Cidade>;
  constructor(private _context:LocalizarCidadeViewModel) 
  {
    this.item = new Cidade("","","");
    this.items = new List<Cidade>();
    this.items.add(new Cidade("709","A","SC"));
    this.items.add(new Cidade("710","B","SC"));
    this.items.add(new Cidade("711","C","SC"));
    this.items.add(new Cidade("712","D","SC"));
    this.items.add(new Cidade("713","E","SC"));
    this.items.add(new Cidade("714","F","SC"));
    this.items.add(new Cidade("715","G","SC"));
    this.items.add(new Cidade("716","H","SC"));
    this.items.add(new Cidade("717","I","SC"));
    this.items.add(new Cidade("718","J","SC"));
  }

  ngOnInit(): void {
    this._context.BuscarDadosCidades();
  }

  onSelect(selecionado:Cidade):void {
    this.item = selecionado;
  }

}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LocalizarCidadeComponent } from './components/localizar-cidade/localizar-cidade.component';
import { MostrarClima7diasComponent } from './components/mostrar-clima7dias/mostrar-clima7dias.component';
import { LocalizarCidadeViewModel } from './viewModels/LocalizarCidadeViewModel';
import { BuscarDadosCidadeService } from './services/BuscarDadosCidadeService';
import { ConfigComponent } from './components/config/config.component';

@NgModule({
  declarations: [
    AppComponent,
    LocalizarCidadeComponent,
    MostrarClima7diasComponent,
    ConfigComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule    
  ],
  providers: [
    BuscarDadosCidadeService,
    LocalizarCidadeViewModel,    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

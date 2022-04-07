import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostrarClima7diasComponent } from './mostrar-clima7dias.component';

describe('MostrarClima7diasComponent', () => {
  let component: MostrarClima7diasComponent;
  let fixture: ComponentFixture<MostrarClima7diasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MostrarClima7diasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MostrarClima7diasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

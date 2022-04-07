import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalizarCidadeComponent } from './localizar-cidade.component';

describe('LocalizarCidadeComponent', () => {
  let component: LocalizarCidadeComponent;
  let fixture: ComponentFixture<LocalizarCidadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LocalizarCidadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LocalizarCidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

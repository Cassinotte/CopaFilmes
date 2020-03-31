import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicacaoFormArrayComponent } from './indicacao.formarray.component';

describe('IndicacaoComponent', () => {
  let component: IndicacaoFormArrayComponent;
  let fixture: ComponentFixture<IndicacaoFormArrayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [IndicacaoFormArrayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicacaoFormArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

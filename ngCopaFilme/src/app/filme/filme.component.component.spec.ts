import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FilmeComponentComponent } from './filme.component.component';

describe('FilmeComponentComponent', () => {
  let component: FilmeComponentComponent;
  let fixture: ComponentFixture<FilmeComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilmeComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmeComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

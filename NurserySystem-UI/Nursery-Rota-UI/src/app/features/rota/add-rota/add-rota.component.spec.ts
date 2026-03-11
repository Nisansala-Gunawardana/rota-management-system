import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRotaComponent } from './add-rota.component';

describe('AddRotaComponent', () => {
  let component: AddRotaComponent;
  let fixture: ComponentFixture<AddRotaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRotaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRotaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

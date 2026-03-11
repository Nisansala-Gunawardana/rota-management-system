import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBreaktimeComponent } from './add-breaktime.component';

describe('AddBreaktimeComponent', () => {
  let component: AddBreaktimeComponent;
  let fixture: ComponentFixture<AddBreaktimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddBreaktimeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBreaktimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

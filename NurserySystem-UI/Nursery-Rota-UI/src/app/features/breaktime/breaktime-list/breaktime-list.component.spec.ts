import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BreaktimeListComponent } from './breaktime-list.component';

describe('BreaktimeListComponent', () => {
  let component: BreaktimeListComponent;
  let fixture: ComponentFixture<BreaktimeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BreaktimeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BreaktimeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

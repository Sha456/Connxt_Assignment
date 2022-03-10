import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidateCreditCardComponent } from './validate-credit-card.component';

describe('ValidateCreditCardComponent', () => {
  let component: ValidateCreditCardComponent;
  let fixture: ComponentFixture<ValidateCreditCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidateCreditCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidateCreditCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

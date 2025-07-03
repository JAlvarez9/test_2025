import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEComponent } from './update-e.component';

describe('UpdateEComponent', () => {
  let component: UpdateEComponent;
  let fixture: ComponentFixture<UpdateEComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateEComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateEComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

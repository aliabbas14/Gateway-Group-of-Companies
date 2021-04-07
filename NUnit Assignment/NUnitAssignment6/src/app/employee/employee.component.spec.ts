import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeComponent } from './employee.component';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('get',async () => {
    var result=await component.get();

    var expected=[
      {"id":1, "name":"abc"},
      {"id":2, "name":"pqr"},
      {"id":3, "name":"xyz"}
     ];

    expect(result.length==expected.length).toBeTruthy();
    expect(component).toBeTruthy();
  });


  it('get by id',async () => {
    var result=await component.getById(1);
    expect(result.name=="abc").toBeTruthy();
    expect(component).toBeTruthy();
  });

  it('post',async () => {

    var result=await component.post({"id":4,"name":"hjk"});
    expect(result=="Employee Added").toBeTruthy();
    expect(component).toBeTruthy();
  });

  it('put',async () => {

    var result=await component.put(1,"lkj");
    expect(result=="Employee Updated").toBeTruthy();
    expect(component).toBeTruthy();
  });

  it('delete',async () => {

    var result=await component.delete(1);
    expect(result=="Employee Deleted").toBeTruthy();
    expect(component).toBeTruthy();
  });


});

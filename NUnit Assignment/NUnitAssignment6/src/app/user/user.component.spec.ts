import { UserService } from './user.service';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import {HttpClientTestingModule} from '@angular/common/http/testing';
import { UserComponent } from './user.component';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;
  let service:UserService;
  

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule] });
    service = TestBed.inject(UserService);
    component = new UserComponent(service);
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });


  it('getUsers', (done) => {

    // Act
    component.getUsers().then((data) => {

      // Assert
      expect(data).toBeTruthy();
      console.log("hello",data);
      done();
    });
  });

  it('getUser', (done) => {

    // Act
    component.getUser(1).then((data) => {

      // Assert
      expect(data).toBeTruthy();
      console.log("hello",data);
      done();
    });
  });

  it('addUser', (done) => {

    // Act
    component.addUser().then((data) => {

      // Assert
      expect(data).toBeTruthy();
      console.log("hello",data);
      done();
    });
  });

  it('updateUser', (done) => {

    // Act
    component.updateUser().then((data) => {

      // Assert
      expect(data).toBeTruthy();
      console.log("hello",data);
      done();
    });
  });

  it('deleteUser', (done) => {

    // Act
    component.deleteUser(1).then((data) => {

      // Assert
      expect(data).toBeTruthy();
      console.log("hello",data);
      done();
    });
  });



});

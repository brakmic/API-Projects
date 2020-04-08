import {
  Component, Inject,
  OnInit, AfterViewInit,
  OnDestroy
} from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import * as _ from 'lodash';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-confirm-account-component',
  templateUrl: './confirm-account.component.html'
})
export class ConfirmAccountComponent implements OnInit,
                                                OnDestroy,
                                                AfterViewInit {

  
  confid: FormControl;
  accid: FormControl;
  name: FormControl;
  email: FormControl;
  password: FormControl;
  confirmAccountForm: FormGroup; 

  sub: Subscription

  constructor(private route: ActivatedRoute,
              private router: Router,
              private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private toastr: ToastrService,
    private builder: FormBuilder) {

  }

  ngOnInit() {

    this.initForm();
    this.sub = this.route
      .queryParams
      .subscribe(params => {
        this.confirmAccountForm.patchValue({ 'AccountId': params['accid'] });
        this.confirmAccountForm.patchValue({ 'ConfirmationId': params['confid'] });
        this.confirmAccountForm.patchValue({ 'Name': params['name'] });
        this.confirmAccountForm.patchValue({ 'Email': params['email'] });
      });
  }

  ngAfterViewInit() {
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  confirmAccount($event: any) {
    this.http.post(this.baseUrl + 'api/registration/confirm',
      {
        ConfirmationId: this.confirmAccountForm.get('ConfirmationId').value,
        AccountId: this.confirmAccountForm.get('AccountId').value,
        Email: this.confirmAccountForm.get('Email').value,
        Name: this.confirmAccountForm.get('Name').value,
        Password: this.confirmAccountForm.get('Password').value
      }).subscribe(result => {
        this.toastr.success("Confirmation completed. Check your mailbox.", "Confirmation");
        this.router.navigate(['/']);
      console.log(result);
    }, error => console.error(error));
  }

  cancelRegistration($event: any) {

  }

  private initForm() {
    this.confid = new FormControl('', [
      Validators.required,
      Validators.minLength(10)
    ]);
    this.accid = new FormControl('', [
      Validators.required,
      Validators.minLength(10)
    ]);
    this.name = new FormControl('', [
      Validators.required,
      Validators.minLength(4)
    ]);
    this.email = new FormControl('', [
      Validators.required
    ]);
    this.password = new FormControl('', [
      Validators.required,
      Validators.minLength(8)
    ]);

    this.confirmAccountForm = this.builder.group({
      ConfirmationId: this.confid,
      AccountId: this.accid,
      Name: this.name,
      Email: this.email,
      Password: this.password
    });
  }

}

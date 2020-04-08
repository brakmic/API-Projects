import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register-account-component',
  templateUrl: './register-account.component.html'
})
export class RegisterAccountComponent implements OnInit,
                                                OnDestroy {

  accid: FormControl;
  name: FormControl;
  email: FormControl;
  registerAccountForm: FormGroup;

  constructor(private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string,
    private builder: FormBuilder,
    private toastr: ToastrService,) {

  }

  ngOnInit() {
    this.initForm();
    // dummy id
    this.registerAccountForm.patchValue({ 'AccountId': '1234567890' });

  }

  ngOnDestroy() {

  }

  registerAccount($event: any) {
    this.http.post(this.baseUrl + 'api/registration/register', {
      AccountId: this.registerAccountForm.get('AccountId').value,
      Name: this.registerAccountForm.get('Name').value,
      Email: this.registerAccountForm.get('Email').value
    })
      .subscribe(result => {
        console.log(result);
        this.toastr.success("Registration email sent.", "Registration");
        this.router.navigate(['/']);
    }, error => console.error(error));
  }

  private initForm() {
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

    this.registerAccountForm = this.builder.group({
      AccountId: this.accid,
      Name: this.name,
      Email: this.email
    });
  }
}

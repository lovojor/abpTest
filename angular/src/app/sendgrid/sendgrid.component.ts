import { Component } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { SendgridService } from '../service/sendgrid.service';

@Component({
  selector: 'app-sendgrid',
  templateUrl: './sendgrid.component.html',
  styleUrls: ['./sendgrid.component.scss']
})
export class SendgridComponent {
  sendgridForm: FormGroup;

  constructor(
    private sendFB: FormBuilder,
    private sendgridService: SendgridService
  ) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.sendgridForm = this.sendFB.group({
      from: new FormControl('', [Validators.required]),
      to: new FormControl('', [Validators.required]),
      message: new FormControl('', [Validators.required])
    });
  }

  pushSendEmail() {
    console.log(this.sendgridForm.value);
    this.sendgridService.PushSend(this.sendgridForm.value).subscribe(data => {
      console.log(data);
    });
  }
}

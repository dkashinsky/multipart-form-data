import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-multipart-form',
  templateUrl: './multipart-form.component.html',
  styleUrls: ['./multipart-form.component.scss']
})
export class MultipartFormComponent implements OnInit {

  public name: string;
  public date: string;
  public avatar: File;
  public cv: File;

  constructor() { }

  ngOnInit() {
  }

  onAvatarChange(file: File) {
    this.avatar = file;
  }

  onCVChange(file: File) {
    this.cv = file;
  }

  upload() {
    //this.httpClient.post
  }
}

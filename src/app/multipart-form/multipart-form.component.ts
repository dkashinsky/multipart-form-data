import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { toFormData, UserModel } from './multipart-form.data';

@Component({
  selector: 'app-multipart-form',
  templateUrl: './multipart-form.component.html',
  styleUrls: ['./multipart-form.component.scss']
})
export class MultipartFormComponent implements OnInit {

  public userData: UserModel;

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.userData = {
      name: null,
      date: null,
      avatar: null,
      cv: null
    };
  }

  onAvatarChange(file: File) {
    this.userData.avatar = file;
  }

  onCVChange(file: File) {
    this.userData.cv = file;
  }

  upload() {
    const uploadUrl = 'http://localhost:63918/api/upload';
    this.httpClient.post<any>(uploadUrl, toFormData(this.userData)).subscribe(result => {
      alert(JSON.stringify(result));
    });
  }
}

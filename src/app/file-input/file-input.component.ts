import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-file-input',
  templateUrl: './file-input.component.html',
  styleUrls: ['./file-input.component.scss']
})
export class FileInputComponent implements OnInit {

  @Input('file') file: File;
  @Input('accept') accept: string[];
  @Output('onFileChange') onFileChange = new EventEmitter<File>();

  @ViewChild('fileInput') fileInput: ElementRef;

  get title() {
    return this.file ? this.file.name : 'Browse...';
  }

  constructor() { }

  ngOnInit() {
  }

  browse() {
    if (this.fileInput.nativeElement) {
      this.fileInput.nativeElement.click();
    }
  }

  onChange(file: File) {
    this.onFileChange.emit(file);
  }
}

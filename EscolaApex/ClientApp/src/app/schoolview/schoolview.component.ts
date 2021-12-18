import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-schoolview',
  templateUrl: './schoolview.component.html',
  styleUrls: ['./schoolview.component.css']
})
export class SchoolviewComponent implements OnInit {

  constructor(private http: HttpClient) { }
  lista: any = [];
  ngOnInit() {
    this.carregarTabela();
  }
  carregarTabela() {
    this.http.get("/api/School/RetornarPessoas")
      .subscribe(result => {
        this.lista = result;
      });
  }
}

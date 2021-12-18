import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pessoa } from './model/pessoa';

@Component({
  selector: 'app-schoolform',
  templateUrl: './schoolform.component.html',
  styleUrls: ['./schoolform.component.css']
})
export class SchoolformComponent implements OnInit {
  pessoa: Pessoa = new Pessoa();
  constructor(private http: HttpClient,private router:Router) { }

  ngOnInit() {
  }
  save() {
    this.http.post("/api/School/CadastrarPessoa", this.pessoa)
      .subscribe((rota: string) => {
        console.log(rota);
        this.pessoa = new Pessoa();
        this.router.navigate(['/upload']);
      });
  }

}

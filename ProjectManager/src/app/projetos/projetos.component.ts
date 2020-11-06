import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Projeto } from '../models/Projeto';
import { ProjetoService } from './projeto.service';

@Component({
  selector: 'app-projetos',
  templateUrl: './projetos.component.html',
  styleUrls: ['./projetos.component.css']
})
export class ProjetosComponent implements OnInit {


  ngOnInit() {
    this.carregarProjetos();
  }

  constructor(private fb:FormBuilder,
    private modalService: BsModalService,
    private projetoService: ProjetoService) {
    this.criarForm();
  }

  carregarProjetos(){
    this.projetoService.getAll().subscribe(
      (projetos) => {this.projetos = projetos},
      (error) => {console.error(error)}
    )
  }
  criarForm(){
    this.projetoForm = this.fb.group({
      id:[],
      nome: ['',Validators.required],
      prazo: ['',Validators.required]
    });
  }
  public projetoSelecionado: Projeto;
  public projetoForm: FormGroup;
  public modalRef: BsModalRef;
  public title = "Projetos";
  public metodo = 'post';
  public projetoModal: Projeto;
  public projetos: Projeto[];
  
  openModal(template: TemplateRef<any>, projeto: Projeto) {
    console.log(projeto);
    this.projetoModal = projeto;
    this.modalRef = this.modalService.show(template);
  }

  selectProjeto(projeto: Projeto){
    this.projetoSelecionado = projeto;
    this.projetoForm.patchValue(projeto);
  }
  novoProjeto(){
    this.projetoSelecionado = new Projeto();
    this.projetoForm.patchValue(this.projetoSelecionado);
  }

  submitProjeto(){
    console.log(this.projetoForm.value);
    this.salvarProjeto(this.projetoForm.value);
    
  }
  

  salvarProjeto(projeto: Projeto){
    (projeto.id === 0 )? this.metodo = 'post' : this.metodo = 'put';
    this.projetoService[this.metodo](projeto).subscribe(
      (data) => {this.carregarProjetos()},
      (error)=>{console.error(error);
      }
    );
  }
 
  deletarProjeto(id:number){
    this.projetoService.delete(id).subscribe(
      (data) => {this.carregarProjetos()},
      (error) => {console.log(error)}
    )
  }

  voltar(){
    this.projetoSelecionado = null;
  }

 

}

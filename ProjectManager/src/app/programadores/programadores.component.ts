import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Programador } from '../models/Programador';
import { Projeto } from '../models/Projeto';
import { ProjetoService } from '../projetos/projeto.service';
import { ProgramadorService } from './programadores.service';

@Component({
  selector: 'app-programadores',
  templateUrl: './programadores.component.html',
  styleUrls: ['./programadores.component.css']
})
export class ProgramadoresComponent implements OnInit {

  public programadorSelecionado: Programador;
  public programadorForm: FormGroup;
  public programadores: Programador[];
  public projetos: Projeto[];
  public title = 'Programadores';
  public metodo ='post';

  public modalRef: BsModalRef;

  constructor(private fb:FormBuilder, 
    private modalService: BsModalService,
    private programadorService: ProgramadorService,
    private projetoService: ProjetoService) {
    this.criarForm();
  }

  criarForm(){
    this.programadorForm = this.fb.group({
      id:[],
      nome: ['',Validators.required],
      telefone:['',Validators.required],
      projetoId:['',Validators.required]
    });
  }
  ngOnInit() {
    this.carregarProgramadores();
    this.carregarProjetos();
  }

  carregarProgramadores(){
    this.programadorService.getAll().subscribe(
        (programadores)=> {this.programadores = programadores},
        (erro)=> {console.error(erro)}
    );
  }

  carregarProjetos(){
    this.projetoService.getAll().subscribe(
        (projetos)=> {this.projetos = projetos},
        (erro)=> {console.error(erro)}
    );
  }

  
  selectProgramador(programador:Programador ){
    this.programadorSelecionado = programador;
    this.programadorForm.patchValue(programador);
  }

  novoProgramador(){
    this.programadorSelecionado = new Programador();
    this.programadorForm.patchValue(this.programadorSelecionado);
  }
  submitProgramador(){
    console.log(this.programadorForm.value);
    this.salvarProgramador(this.programadorForm.value);
    
  }

  salvarProgramador(programador: Programador){
    (programador.id === 0 ) ? this.metodo ='post' : this.metodo = 'put';
    this.programadorService[this.metodo](programador).subscribe(
      (data) => {this.carregarProgramadores()},
      (error)=>{console.error(error);
      }
    );
  }

  deletarProgramador(id:number){
    this.programadorService.delete(id).subscribe(
      (data) => {this.carregarProgramadores()},
      (error) => {console.log(error)}
    )
  }

  voltar(){
    this.programadorSelecionado = null;
  }
 

}

import { Projeto } from './Projeto';

export class Programador{

    constructor() {
        this.id = 0,
        this.nome = '',
        this.telefone ='',
        this.projeto = null,
        this.projetoId = 0 
    }
    
    id:Number;
    nome:String;
    telefone:String;
    projeto:Projeto;
    projetoId:Number;
}
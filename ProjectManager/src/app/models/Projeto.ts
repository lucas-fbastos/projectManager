import { Programador } from './Programador';
export class Projeto{

    constructor() {
        this.id=0,
        this.nome='',
        this.prazo='',
        this.programadores=[];
    }
    id:Number;
    nome:string;
    prazo:string;
    programadores: Programador[];
}
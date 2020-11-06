import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { AttachSession } from 'protractor/built/driverProviders';
import { Projeto } from '../models/Projeto';
import { DashBoardService } from './dashboard.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor( private dashBoardService: DashBoardService) { }
  public chartOptions: {};
  public chartOptionsTime: {};
  public programadoresPorProjeto = [];
  public proximoProjeto: Projeto;
  public quantidadeProjetos: Number;
  public quantidadeProgramadores: Number;
  public menorProjeto: string;
  public projetosVencidos: Projeto[];
  Highcharts = Highcharts;

  setDados(data: any[]){
    let items = Array<{name: string, y: number}>();
    for(let key in data['quantitativos']){
      let obj = {name: key, y: data['quantitativos'][key]};
      items.push(obj);
    }
    this.programadoresPorProjeto = items;
    this.quantidadeProgramadores = data['quantidadeProgramadores'];
    this.quantidadeProjetos = data['quantidadeProjetos'];
    this.menorProjeto = data['projetoComMenosProgramadores'];
    this.proximoProjeto = data['proximoProjeto'];
    this.projetosVencidos = data['projetosVencidos'];
  }

  ngOnInit() {
    this.dashBoardService.getAll().subscribe(
      (data) => {
                  this.setDados(data);
                  this.chartOptions = {
                    chart: {
                      plotBackgroundColor: null,
                      plotBorderWidth: null,
                      plotShadow: false,
                      type: 'pie'
                  },
                  title: {
                      text: 'Programadores por Projeto'
                  },
                  tooltip: {
                      pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                  },
                  accessibility: {
                      point: {
                          valueSuffix: '%'
                      }
                  },
                  plotOptions: {
                      pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      }
                  },
                  series: [{
                      name: 'Programadores',
                      colorByPoint: true,
                      data: this.programadoresPorProjeto,
                  }]
                  };
                },
      (err) => {console.error(err)}
    );
   
  }

}

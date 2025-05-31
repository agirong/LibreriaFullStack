import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from './interface/weatherforecast.interface';
import { parametro } from './interface/parametro.interface';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  public parametro: parametro[]=[];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
    this.getParametro();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getParametro(){
    this.http.get<parametro[]>('https://localhost:7290/api/Parametro').subscribe(
      (result)=>{
        this.parametro = result;
        console.log(this.parametro);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  title = 'appangular.client';
}

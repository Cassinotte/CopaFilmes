// //https://blogs.msdn.microsoft.com/premier_developer/2018/03/01/angular-how-to-editable-config-files/
// https://www.angularjswiki.com/angular/how-to-read-local-json-files-in-angular/
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable()
export class AppConfig {
  static settings: any;

    constructor(private http: HttpClient) {
      let config =  {
        ApiBackend: "",
        MaxFilmes: 0
      }    
      AppConfig.settings = config ;
    }
    load() {
        const jsonFile = `assets/config/config.${environment.name}.json`;
        return new Promise<void>((resolve, reject) => {
            this.http.get(jsonFile).toPromise().then(response => {
               AppConfig.settings = response;
               resolve();
            }).catch((response: any) => {
               reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
            });
        });
    }
}

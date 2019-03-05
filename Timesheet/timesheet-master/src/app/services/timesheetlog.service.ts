import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class TimesheetLogService {
    private baseapi = environment.apiUrl;
    constructor(private http: HttpClient) { }

    getallTimesheetLogs(selectedval) {
        return this.http.get(this.baseapi + "/timesheetlog/getall/"+selectedval);
    }

    saveTimesheetLogs(selectedval) {
        return this.http.post(this.baseapi + "/timesheetlog/postreq/",selectedval
        );
    }

}
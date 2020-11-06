import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { Score } from './models/score';
import { PopupInfoComponent } from './popup-info/popup-info.component';
import { PopupRgpdComponent } from './popup-rgpd/popup-rgpd.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    @ViewChild('modaleRgpd') modaleRgpd: PopupRgpdComponent;
    @ViewChild('modaleInfo') modaleInfo: PopupInfoComponent;
    score: Score;
    scores: Score[];
    eventsSubject: Subject<Score[]> = new Subject<Score[]>();
    modaleCliquee = false;
    modaleInfoCliquee = false;

    constructor(private http: HttpClient) { }

    ngOnInit() {
        let locStScores = localStorage.getItem('scores');
        if (locStScores != null) {
            let objScore = JSON.parse(locStScores);
            this.scores = objScore.scores;
            this.score = objScore.scoreSelect;
        }
    }

    selectCommune(searchedCodeInsee: string) {
        if (!searchedCodeInsee) return;
        this.http.get("api/Communes/" + searchedCodeInsee + "/Getscore").subscribe((res: Score[]) => {
            this.score = res[0];
            this.scores = res;
            this.SetScoresInLocalStorage();
            this.eventsSubject.next(res);
        });
    }

    selectIntercomm(searchedIntercommId: string) {
        if (!searchedIntercommId) return;
        this.http.get("api/Communes/" + searchedIntercommId + "/GetIntercommScore").subscribe((res: Score[]) => {
            this.score = res[0];
            this.scores = res;
            this.SetScoresInLocalStorage();
            this.eventsSubject.next(res);
        });
    }

    refreshScore(codeIris: string) {
        this.http.get("api/Communes/Quartiers/" + codeIris + "/GetScore").subscribe((res: Score[]) => {
            this.score = res[0];
            localStorage.setItem('scores', JSON.stringify({ scoreSelect: this.score, scores: this.scores }));
        });
    }

    lancerExport() {
        window.location.href = '/api/Historiques';
    }

    private SetScoresInLocalStorage() {
        localStorage.setItem('scores', JSON.stringify({ scoreSelect: this.score, scores: this.scores }));
    }

    afficherModale() {
        this.modaleCliquee = true;
        setTimeout(() => {
            document.getElementById('modal-rgpd').style.display = 'block';
        }, 150);
    }
    afficherModaleInfo() {
        this.modaleInfoCliquee = true;
        setTimeout(() => {
            document.getElementById('modal-info').style.display = 'block';
        }, 150);
    }
}

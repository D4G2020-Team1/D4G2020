import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { NgSelectConfig } from '@ng-select/ng-select';
import { Commune } from '../models/commune';
import { Departement } from '../models/departement';
import { Epci } from '../models/epci';
import { Region } from '../models/region';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss']
})

export class SearchComponent {
    @Output() onCommuneSelected: EventEmitter<string> = new EventEmitter();
    @Output() onIntercommSelected: EventEmitter<string> = new EventEmitter();
    selectedRegion = -1;
    selectedDepartement = "";
    selectedIntercomm = "";
    selectedCommune = "";
    regions: Region[] = [];
    departements: Departement[] = [];
    departementsRef: Departement[] = [];
    intercomms: Epci[] = [];
    communes: Commune[] = [];
    timeoutEpci: number;
    timeoutCommune: number;

    constructor(private config: NgSelectConfig, private http: HttpClient) {
        this.config.notFoundText = 'Tapez au moins 3 caractères pour lancer la recherche';
        this.config.clearAllText = 'Tout effacer';
    }

    ngOnInit() {
        this.regions.unshift({ libelle: "Toutes", regionId: -1 });
        this.selectedRegion = -1;
        this.departementsRef.unshift({ libelle: "Tous", departementId: "", regionId: -1 });
        this.departements.unshift({ libelle: "Tous", departementId: "", regionId: -1 });

        this.http.get("api/Communes/Regions").subscribe((res: Region[]) => {
            this.regions.push(...res);
        });

        this.http.get("api/Communes/Departements").subscribe((res: Departement[]) => {
            this.departementsRef.push(...res);
            this.departements.push(...res);
        });

        let locStFilter = localStorage.getItem('filterScores');
        if (locStFilter != null) {
            const filter = JSON.parse(locStFilter);
            if (filter != null) {
                this.selectedRegion = filter.selectedRegion;
                this.selectedDepartement = filter.selectedDepartement;
                this.selectedIntercomm = filter.selectedIntercomm;
                this.selectedCommune = filter.selectedCommune;
                this.communes = filter.communes;
                this.intercomms = filter.intercomms;
            }
        }
    }

    getEpcis(event) {
        if (event.term && event.term.length >= 3) {
            this.config.notFoundText = 'Aucun résultat trouvé';
            console.log(this.config.notFoundText);
            clearTimeout(this.timeoutEpci);
            this.timeoutEpci = setTimeout(() => {
                const params = new HttpParams().set("nom", event.term).set("regionId", this.selectedRegion.toString()).set("departementId", this.selectedDepartement);
                this.http.get("api/Communes/Epcis", { params: params }).subscribe((res: Epci[]) => {
                    this.intercomms = res;
                });
            }, 500);
        }
    }

    getCommunes(event) {
        if (event.term && event.term.length >= 3) {
            clearTimeout(this.timeoutCommune);
            this.timeoutCommune = setTimeout(() => {
                const params = new HttpParams().set("recherche", event.term).set("regionId", this.selectedRegion.toString()).set("departementId", this.selectedDepartement).set("epciId", this.selectedIntercomm);
                this.http.get("api/Communes/Recherche", { params: params }).subscribe((res: Commune[]) => {
                    this.communes = res;
                });
            }, 500);
        } 
    }

    changeRegionSelected(regionId: number) {
        if (regionId !== -1)
            this.departements = [...this.departementsRef].filter(d => d.regionId === regionId || d.regionId === -1);
        else
            this.departements = [...this.departementsRef];

        this.intercomms = [];
        this.communes = [];
        this.selectedDepartement = "";
        this.selectedIntercomm = "";
        this.selectedCommune = "";
    }

    changeDepartementSelected() {
        this.intercomms = [];
        this.communes = [];
        this.selectedIntercomm = "";
        this.selectedCommune = "";
    }

    changeIntercommSelected() {
        this.communes = [];
        this.selectedCommune = "";

        this.enregistreFilterLocalStorage();
        this.onIntercommSelected.emit(this.selectedIntercomm);
    }

    changeCommuneSelected() {
        this.enregistreFilterLocalStorage();
        this.onCommuneSelected.emit(this.selectedCommune);
    }

    private enregistreFilterLocalStorage() {
        const filter = {
            selectedDepartement: this.selectedDepartement,
            selectedIntercomm: this.selectedIntercomm,
            selectedCommune: this.selectedCommune,
            selectedRegion: this.selectedRegion,
            communes: this.communes,
            intercomms: this.intercomms
        }
        localStorage.setItem('filterScores', JSON.stringify(filter));
    }
} 

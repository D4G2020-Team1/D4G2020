import { Component, ComponentFactoryResolver, EventEmitter, Injector, Input, Output } from '@angular/core';
import * as L from 'leaflet';
import { Observable, Subscription } from 'rxjs';
import { DataTooltipComponent } from '../data-tooltip/data-tooltip.component';
import { Score } from '../models/score';

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.scss']
})

export class MapComponent {
    map;
    @Input() scores: Score[];
    @Input() events: Observable<Score[]>;
    @Output() onClickItemMap: EventEmitter<string> = new EventEmitter();
    private eventsSubscription: Subscription;
    displayedPolygons: L.Polygon[] = [];
    constructor(private resolver: ComponentFactoryResolver, private injector: Injector) {}

    ngOnDestroy() {
        this.eventsSubscription.unsubscribe();
    }

    ngAfterViewInit() {
        if (this.scores) {
            this.createMap();
            this.eventsSubscription = this.events.subscribe((data) => this.updateMap(data));
        }
    }

    clearMap() {
        for (let i in this.map._layers) {
            if (this.map._layers[i]._path !== undefined) {
                try {
                    this.map.removeLayer(this.map._layers[i]);
                }
                catch (e) {
                    console.log("problem with " + e + this.map._layers[i]);
                }
            }
        }
    }

    updateMap(data: Score[]) {
        this.displayedPolygons = [];
        for (let i in this.map._layers) {
            if (this.map._layers[i]._path !== undefined) {
                try {
                    this.map.removeLayer(this.map._layers[i]);
                }
                catch (e) {
                    console.log("problem with " + e + this.map._layers[i]);
                }
            }
        }
        const polygonsArr = [];
        const poly = [];

        data.forEach(p => {
            //Parse les coordonnées de [long, lat] (à l'envers par rapport à ce qu'attend Leaflet) vers un objet LatLng
            const geoShape = JSON.parse(p.geoShape);
            for (let i = 0; i < geoShape.coordinates.length; i++) {
                polygonsArr[i] = [];
                for (let j = 0; j < geoShape.coordinates[i].length; j++) {
                    polygonsArr[i][j] = new L.LatLng(geoShape.coordinates[i][j][1], geoShape.coordinates[i][j][0]);
                }
            }
            const factory = this.resolver.resolveComponentFactory(DataTooltipComponent);
            const component = factory.create(this.injector);
            component.instance.data = p;
            component.changeDetectorRef.detectChanges();

            let couleur = "#5DA6BD";
            if (p.scoreGlobalReg < 70) {
                couleur = "#BEE1DA"
            } else if (p.scoreGlobalReg > 70 && p.scoreGlobalReg < 100) {
                couleur = "#7ABBC8";
            }
            else if (p.scoreGlobalReg >= 130) {
                couleur = "#5E757D";
            }
            const polygon = L.polygon(polygonsArr, { color: couleur, fillColor: couleur, opacity: 1, fillOpacity: 0.4 }).bindTooltip(component.location.nativeElement, {
                sticky: true // If true, the tooltip will follow the mouse instead of being fixed at the feature center.
            }).addTo(this.map);
            polygon.on('click', (event) => {
                //On récupère le code iris
                const codeIris = event.target._tooltip._content.firstChild.id;
                this.displayedPolygons.filter(p => p.options.fillColor === "#513977").forEach(p => p.setStyle({ fillColor: "#7ABBC8" }));
                polygon.setStyle({ fillColor: "#513977" });

                this.displayedPolygons.filter(p => p.options.color === "#513977").forEach(p => p.setStyle({ color: "#7ABBC8" }));
                polygon.setStyle({ color: "#513977" });
                this.onClickItemMap.emit(codeIris);
            })
            this.displayedPolygons.push(polygon);
            poly.push(polygon);
        });

        const bounds = poly.map(p => p.getBounds());
        this.map.fitBounds(bounds);
    }

    createMap() {
        this.displayedPolygons = [];

        this.map = L.map('map', {
            center: [47.4667, -0.55],
            zoom: 7
        });

        const mainLayer = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            minZoom: 2,
            maxZoom: 17,
            attribution: '&copy; <a href="https://www/openstreetmap/org/copyright">OpenstreetMap</a> contributors'
        });
        this.map.zoomControl.setPosition('topright');
        mainLayer.addTo(this.map);

        const polygonsArr = [];
        const poly = [];
        this.scores.forEach(p => {
            //Parse les coordonnées de [long, lat] (à l'envers par rapport à ce qu'attend Leaflet) vers un objet LatLng
            const geoShape = JSON.parse(p.geoShape);
            for (let i = 0; i < geoShape.coordinates.length; i++) {
                polygonsArr[i] = [];
                for (let j = 0; j < geoShape.coordinates[i].length; j++) {
                    polygonsArr[i][j] = new L.LatLng(geoShape.coordinates[i][j][1], geoShape.coordinates[i][j][0]);
                }
            }
            const factory = this.resolver.resolveComponentFactory(DataTooltipComponent);
            const component = factory.create(this.injector);
            component.instance.data = p;
            component.changeDetectorRef.detectChanges();

            let couleur = "#5DA6BD";
            if (p.scoreGlobalReg < 70) {
                couleur = "#BEE1DA"
            } else if (p.scoreGlobalReg > 70 && p.scoreGlobalReg < 100) {
                couleur = "#7ABBC8";
            }
            else if (p.scoreGlobalReg >= 130) {
                couleur = "#5E757D";
            }
            const polygon = L.polygon(polygonsArr, { color: couleur, fillColor: couleur, opacity: 1, fillOpacity: 0.4  }).bindTooltip(component.location.nativeElement, {
                sticky: true // If true, the tooltip will follow the mouse instead of being fixed at the feature center.
            }).addTo(this.map);
            polygon.on('click', (event) => {
                //On récupère le code iris
                const codeIris = event.target._tooltip._content.firstChild.id;
                this.displayedPolygons.filter(p => p.options.fillColor === "#513977").forEach(p => p.setStyle({ fillColor: "#7ABBC8" }));
                polygon.setStyle({ fillColor: "#513977" });
                this.displayedPolygons.filter(p => p.options.color === "#513977").forEach(p => p.setStyle({ color: "#7ABBC8" }));
                polygon.setStyle({ color: "#513977" });
                this.onClickItemMap.emit(codeIris);
            });
            this.displayedPolygons.push(polygon);
            poly.push(polygon);
        });
        const bounds = poly.map(p => p.getBounds());
        this.map.fitBounds(bounds);
    }
}

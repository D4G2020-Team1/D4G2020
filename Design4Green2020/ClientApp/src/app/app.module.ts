import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponent } from './search/search.component';
import { HeaderComponent } from './header/header.component';
import { MapComponent } from './map/map.component';

import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { DataTooltipComponent } from './data-tooltip/data-tooltip.component';
import { ScoreComponent } from './score/score.component';
import { HttpClientModule } from '@angular/common/http';
import { PopupRgpdComponent } from './popup-rgpd/popup-rgpd.component';
import { DetailInfnComponent } from './detail-infn/detail-infn.component';
import { PopupInfoComponent } from './popup-info/popup-info.component';

@NgModule({
    declarations: [
        AppComponent,
        SearchComponent,
        HeaderComponent,
        MapComponent,
        DataTooltipComponent,
        ScoreComponent,
        DetailInfnComponent,
        PopupRgpdComponent,
        PopupInfoComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        NgSelectModule,
        HttpClientModule,
        FormsModule
    ],
    entryComponents: [DataTooltipComponent],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }

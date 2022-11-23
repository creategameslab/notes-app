import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NotesService } from './services/notes.service';
import NotesListView from './views/notesListView.component';
import { NoteView } from './views/noteView.component';
import router from './router';
import { NotePage } from './pages/notesPage.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,
        NotesListView,
        NoteView,
        NotePage
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        router
    ],
    providers: [
        NotesService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

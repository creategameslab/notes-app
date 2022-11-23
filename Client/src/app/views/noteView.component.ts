import { Component, Input } from "@angular/core";
import { NotesService } from "../services/notes.service";
import { Note } from "../shared/Note";

@Component({
    selector: "note",
    templateUrl: "noteView.component.html"
})
export class NoteView {
    @Input() item!: Note;

    constructor(public noteService: NotesService) {

    }
}
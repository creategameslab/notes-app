import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { NotesService } from "../services/notes.service";
import { Note } from "../shared/Note";

@Component({
    selector: "notes-list",
    templateUrl: "notesListView.component.html"
})
export default class NotesListView implements OnInit {

    constructor(public noteService: NotesService, private route: ActivatedRoute) {
        route.params.subscribe(val => {
            this.loadNotes();
        });
    }

    ngOnInit(): void {
        this.loadNotes();
    }

    loadNotes(): void {
        let noteId: string | null = this.route.snapshot.paramMap.get('id');

        this.noteService.editing = false;
        this.noteService.note = new Note();

        if (this.noteService.loaded === false) {
            this.noteService.loadNotes().subscribe(() => {
                this.noteService.loaded = true;

                if (noteId!.length > 0) {
                    this.noteService.setNote(noteId);
                }
            });
        } else if (noteId!.length > 0) {
            this.noteService.setNote(noteId);
        }
    }
}
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Note } from "../shared/Note";

@Injectable()
export class NotesService {
    public notes!: Note[];
    public note: Note = new Note();
    editing: boolean = false;
    public loaded: boolean = false;

    constructor(private http: HttpClient, private router: Router) {

    }

    loadNotes() : Observable<void> {
        return this.http.get<Note[]>("/api/notes")
            .pipe(map(data => {
                this.notes = data;

                return;
            }));
    }

    addNote(): void {
        if (this.editing) {
            this.http.patch<Note>(`/api/notes/${this.note.id}`, this.note)
                .subscribe((data) => {
                    this.editing = false;
                    
                    const index = this.notes.indexOf(this.note, 0);
                    if (index > -1) {
                        this.notes.splice(index, 1);
                    }

                    this.note = new Note();
                    this.notes.push(data);
                    this.router.navigate(['/']);
                });
        }
        else {
            this.http.post<Note>("/api/notes", this.note)
                .subscribe((data) => {
                    this.notes.push(data);
                    this.note = new Note();
                    this.note.rawText = "";
                });
        }
    }

    edit(id: string | null): void {
        this.editing = false;
        this.router.navigate([`/note/${id}`]);
    }

    setNote(id: string | null) : void {
        // Could have added a new page for editing but in the interest of time we are going to hijack the same page.
        let item!: Note | undefined;

        item = this.notes.find(o => o.id === id);

        if (item) {
            this.note = item;
            this.editing = true;
        }
    }

    deleteNote(note: Note): void {
        this.http.delete<boolean>(`/api/notes/${note.id}`)
            .subscribe(() => {
                const index = this.notes.indexOf(note, 0);
                if (index > -1) {
                    this.notes.splice(index, 1);
                }
            });
    }
}
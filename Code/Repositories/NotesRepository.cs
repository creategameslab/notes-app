using Notes.Code.Entities;
using System.Collections.Concurrent;

namespace Notes.Code.Repositories
{
    public sealed class NotesRepository : INotesRepository
    {
        private static ConcurrentDictionary<string, Note> _notes = new ConcurrentDictionary<string, Note>();

        public Task<bool> AddNoteAsync(Note note)
        {
            return Task.FromResult(_notes.TryAdd(note.Id, note));
        }

        public Task<bool> DeleteNoteAsync(string id)
        {
            return Task.FromResult(_notes.Remove(id, out _));
        }

        public Task<Note> GetNoteByIdAsync(string id)
        {
            if (_notes.TryGetValue(id, out Note note))
                return Task.FromResult(note);

            return Task.FromResult(default(Note));
        }

        public Task<ICollection<Note>> GetNotesAsync()
        {
            return Task.FromResult<ICollection<Note>>(_notes.Select(s => s.Value).ToList());
        }

        public Task<bool> UpdateNoteAsync(string id, Note updatedNote)
        {
            if (_notes.TryGetValue(id, out Note note))
            {
                return Task.FromResult(_notes.TryUpdate(id, updatedNote, note));
            }
            
            return Task.FromResult(false);
        }
    }
}

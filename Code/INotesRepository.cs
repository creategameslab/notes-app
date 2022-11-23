using Notes.Code.Entities;

namespace Notes.Code
{
    public interface INotesRepository
    {
        Task<ICollection<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(string id);
        Task<bool> AddNoteAsync(Note note);
        Task<bool> UpdateNoteAsync(string id, Note note);
        Task<bool> DeleteNoteAsync(string id);
    }
}

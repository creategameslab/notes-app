import { RouterModule } from "@angular/router";
import { NotePage } from "../pages/notesPage.component";

const routes = [
    { path: "", component: NotePage },
    { path: "note/:id", component: NotePage },
    { path: "**", redirectTo: "/" }
];

const router = RouterModule.forRoot(routes, { useHash: true });

export default router;
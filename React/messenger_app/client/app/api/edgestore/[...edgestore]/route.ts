import { initEdgeStore } from "@edgestore/server";
import { createEdgeStoreNextHandler } from "@edgestore/server/adapters/next/app";

// Verificăm dacă variabilele există
if (!process.env.EDGE_STORE_ACCESS_KEY || !process.env.EDGE_STORE_SECRET_KEY) {
  throw new Error(
    "Missing EDGE_STORE_ACCESS_KEY or EDGE_STORE_SECRET_KEY in environment"
  );
}

// Creăm instanța EdgeStore (fără argumente)
const es = initEdgeStore.create();

const edgeStoreRouter = es.router({
  publicFiles: es.fileBucket(),
});

const handler = createEdgeStoreNextHandler({ router: edgeStoreRouter });

export { handler as GET, handler as POST };
export type EdgeStoreRouter = typeof edgeStoreRouter;

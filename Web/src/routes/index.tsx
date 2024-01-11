import { component$ } from "@builder.io/qwik";
import type { DocumentHead } from "@builder.io/qwik-city";

export default component$(() => {
  return (
    <>
      <h1>hi</h1>
    </>
  );
});

export const head: DocumentHead = {
  title: "Carroponte Scada",
  meta: [
    {
      name: "description",
      content: "Carroponte Scada",
    },
  ],
};

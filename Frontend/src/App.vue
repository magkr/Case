<script setup>

</script>

<template>
  <div class="w-full h-dvh flex flex-col">
    <div class="w-full bg-slate-500 h-12 flex">
      <router-link :to="{ name: 'login' }" class="h-full flex px-4 hover:bg-slate-400/50 cursor-pointer">
        <p class="my-auto text-lg text-white font-bold">
          Log ind
        </p>
      </router-link>
      <router-link :to="{ name: 'create' }" c class="h-full flex px-4 hover:bg-slate-400/50 cursor-pointer">
        <p class="my-auto text-lg text-white font-bold">
          Opret
        </p>
      </router-link>
    </div>
    <main class="w-full h-full flex justify-center">
      <router-view />
    </main>
  </div>
</template>

<style scoped></style>

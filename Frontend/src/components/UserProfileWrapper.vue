<script setup>
import { onMounted } from 'vue';
import { useStore } from '../store.js'
import { useRouter, useRoute } from 'vue-router'

const router = useRouter()
const route = useRoute()
const store = useStore()

onMounted(async () => {
  await store.getUserProfile(route.params.email)
})

const deleteUserProfile = async () => {
  await store.deleteUserProfile(store.currentUserProfile.email)

  if (!store.error) {
    router.push({ name: 'login' })
  }
}
</script>

<template>
  <div v-if="!store.loading" class="grow m-5 bg-slate-200 p-4 rounded-lg">
    <div class="w-full flex justify-between">
      <h1 class="text-xl font-medium">Brugerprofil</h1>
      <button @click="deleteUserProfile" class="bg-red-400 px-2 py-1 rounded-md text-sm">Delete</button>
    </div>
    <router-view></router-view>
  </div>
  <div v-else class="my-auto">Loading...</div>
</template>

<style scoped></style>

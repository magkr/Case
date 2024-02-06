<script setup>
import { ref } from 'vue'
import { useStore } from '../store.js'
import { storeToRefs } from 'pinia'
import { useRouter } from 'vue-router'

const router = useRouter()
const store = useStore()

const { currentUserProfile, error } = storeToRefs(store)

const email = ref('')

const login = async () => {
  await store.getUserProfile(email.value)

  if (currentUserProfile.value) {
    router.push({ name: 'user', params: { email: currentUserProfile.value.email } })
  }
}
</script>

<template>
  <div class="w-full h-full flex items-center justify-center">
    <div class="bg-slate-200 rounded-md p-2 w-2/3 flex flex-col">
      <p class="mb-2 text-lg font-medium">
        Log ind her
      </p>
      <input type="text" placeholder="Email" class="rounded px-2 py-1 mb-2" v-model="email" />
      <p v-if="error" class="mb-2 text-red-700 text-xs ml-1">{{ error.message }}</p>
      <button @click="login" class="w-fit mx-auto bg-slate-400 px-2 py-1 rounded-md">Log ind</button>
    </div>
  </div>
</template>

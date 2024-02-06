<script setup>
import { ref } from 'vue'

import { useStore } from '../store.js'
import { storeToRefs } from 'pinia'
import { useRouter } from 'vue-router'

const router = useRouter()
const store = useStore()

const { currentUserProfile, error } = storeToRefs(store)

const email = ref('')
const name = ref('')
const artistName = ref('')


const create = async () => {
    await store.createUserProfile({
        "email": email.value,
        "name": name.value,
        "artistName": artistName.value
    })

    if (currentUserProfile.value) {
        router.push({ name: 'user', params: { email: currentUserProfile.value.email } })
    }
}
</script>

<template>
    <div class="w-full h-full flex items-center justify-center">
        <div class="bg-slate-200 rounded-md p-2 w-2/3 flex flex-col">
            <p class="mb-2 text-lg font-medium">
                Opret bruger
            </p>
            <input type="text" placeholder="Email (Påkrævet)" class="rounded px-2 py-1 mb-2" v-model="email" />
            <input type="text" placeholder="Navn (Påkrævet)" class="rounded px-2 py-1 mb-2" v-model="name" />
            <input type="text" placeholder="Kunsternavn" class="rounded px-2 py-1 mb-2" v-model="artistName" />
            <p v-if="error" class="mb-2 text-red-700 text-xs ml-1">{{ error.message }}</p>
            <button @click="create" class="w-fit mx-auto bg-slate-400 px-2 py-1 rounded-md">Opret</button>
        </div>
    </div>
</template>

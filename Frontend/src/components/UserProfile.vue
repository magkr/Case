<script setup>
import { ref } from 'vue'
import { useStore } from '../store.js'
import { storeToRefs } from 'pinia'

const store = useStore()

const edit = ref(false)
const { currentUserProfile } = storeToRefs(store)
const name = ref('')

const updateName = async () => {
    store.updateName(name.value)
}
</script>

<template>
    <div v-if="store.currentUserProfile" class="w-full h-full flex flex-col py-2 gap-y-5">
        <div>
            <p class="font-medium">Email</p>
            <p>{{ currentUserProfile.email }}</p>
        </div>
        <div class="relative">
            <p class="font-medium">Navn</p>
            <div v-if="edit">
                <input class="mb-1 px-2 py-1 rounded-md" placeholder="Navn" v-model="name" />
                <div class="flex gap-x-2">
                    <button @click="edit = false" class="text-xs bg-slate-300 p-1 rounded">Cancel</button>
                    <button @click="updateName" class="text-xs bg-slate-300 p-1 rounded">Gem</button>
                </div>
            </div>
            <div v-else>
                <p class="mb-1">{{ currentUserProfile.name }}</p>
                <button @click="edit = true" class="text-xs bg-slate-300 p-1 rounded">Rediger</button>
            </div>
        </div>
        <div>
            <p class="font-medium">Kunsternavn</p>
            <p v-if="currentUserProfile.artistName">{{ currentUserProfile.artistName }}</p>
            <p v-else class="text-sm font-light">Intet valgt</p>
        </div>
    </div>
</template>

<style scoped></style>

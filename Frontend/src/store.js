import axios from 'axios'
import { defineStore } from 'pinia'

export const useStore = defineStore('store', {
    state: () => ({
        error: undefined,
        currentUserProfile: undefined,
        loading: false
    }),
    getters: {
    },
    actions: {
        async getUserProfile(email) {
            this.loading = true;
            this.clear()
            await axios.get(`https://localhost:7096/api/userprofiles/${email}`)
                .then((response) => {
                    this.currentUserProfile = response.data;
                })
                .catch((error) => {
                    this.error = error;
                    console.error(error);
                })
                .finally(() => this.loading = false)
        },
        async createUserProfile(request) {
            this.clear()
            await axios.post(`https://localhost:7096/api/userprofiles`, request)
                .then((response) => {
                    this.currentUserProfile = response.data;
                })
                .catch((error) => {
                    if (error.response?.data) {
                        this.error = error.response.data
                    } else {
                        this.error = error
                    }
                    console.error(error);
                })
        },
        async deleteUserProfile(email) {
            this.clear()
            await axios.delete(`https://localhost:7096/api/userprofiles/${email}`)
                .then(() => {
                })
                .catch((error) => {
                    this.error = error;
                    console.error(error);
                })
        },
        async updateName(name) {
            this.error = undefined;
            await axios.put(`https://localhost:7096/api/userprofiles/${this.currentUserProfile.email}`, {
                ...this.currentUserProfile,
                name: name,
            })
                .then(() => {
                    this.getUserProfile(this.currentUserProfile.email)
                })
                .catch((error) => {
                    this.error = error;
                    console.error(error);
                })
        },
        clear() {
            this.error = undefined;
            this.currentUserProfile = undefined
        }
    },
})

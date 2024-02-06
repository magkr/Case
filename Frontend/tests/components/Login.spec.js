import { afterEach, beforeEach, describe, it, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createRouterMock } from 'vue-router-mock'
import { createTestingPinia } from '@pinia/testing'
import Login from '../../src/components/Login.vue'

/**
 * @vitest-environment jsdom
 */
describe('Login', () => {
    var wrapper;

    beforeEach(() => {
        wrapper = mount(Login, {
            global: {
                plugins: [
                    createTestingPinia({ createSpy: vi.fn }),
                    createRouterMock()
                ]
            }
        })
    })

    afterEach(() => vi.clearAllMocks())

    it('renders correctly', async () => {
        expect(wrapper.exists()).toBe(true)
        expect(wrapper.find('.bg-slate-200').exists()).toBe(true)
        expect(wrapper.find('input').exists()).toBe(true)
        expect(wrapper.find('button').exists()).toBe(true)
    })
})

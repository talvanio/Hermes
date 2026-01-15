// TODO: implementation of jwt login and logout features

"use client"

import { useRouter } from 'next/navigation'

export interface LoginCredentials {
  username: string;
  password: string;
}

export function useAuth() {
    const router = useRouter();

    const login = async (credentials: LoginCredentials) => {
        console.log("logging in...", credentials)
        router.push("/")
    }

    const logout = () => {
        console.log("logging out...")

        router.push("/login")
    }

    return {
        logout,
        login,
        isAuthenticated: false,
    }
}
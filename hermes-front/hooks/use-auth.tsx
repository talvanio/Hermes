"use client"

import { useRouter } from 'next/navigation'

export interface LoginCredentials {
  username: string;
  password: string;
}

export function useAuth() {
    const router = useRouter();

    const login = async (credentials: LoginCredentials) => {
        const response = await fetch(`${process.env.NEXT_PUBLIC_API_BASE_URL}/login`, {
            method:'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(credentials),
        });
        if (!response.ok)
        {
        const error: any = new Error('Erro na requisição');
        error.status = response.status; 
        throw error;
        }

    return await response.json();
};

    const logout = () => {
        console.log("logging out...");
        console.log(process.env.NEXT_PUBLIC_API_BASE_URL);
        router.push("/login");
    }

    return {
        logout,
        login,
        isAuthenticated: false,
    }
}
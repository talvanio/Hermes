"use client"
import {Button} from '@/components/shadcn/ui/button';
import { Input } from '@/components/shadcn/ui/input';
import { Link } from 'lucide-react';
import { useRouter } from 'next/navigation'
import { LoginCredentials, useAuth } from '@/hooks/use-auth';
import { useState } from 'react';

export default function LoginScreen() {
    const router = useRouter()
    const {login} = useAuth()
    const [credentials, setCredentials] = useState<LoginCredentials>({
        username: '',
        password: '',
    })

    return (
        <div className="flex flex-col items-center justify-center min-h-screen px-4 py-12">
            {/* Title Section */}
            <div className='text-center mb-12 max-w-2xl'>
                <h1 className="scroll-m-20 text-3xl md:text-5xl font-extrabold tracking-tight text-balance">
                    <span className="text-orange-400">HERMES:</span> Urban Dispatching System
                </h1>
            </div>

            <form
                onSubmit={(e) => {
                        e.preventDefault();
                        const formData = new FormData(e.currentTarget);
                        const data = Object.fromEntries(formData.entries()) as unknown as LoginCredentials;
                        login(data);
                    }}
                className="w-full max-w-sm space-y-4"
            >
                <div className="space-y-2">
                    <Input name="username" placeholder="Username"  required aria-label="Username"/>
                    <Input name="password" type="password" placeholder="Password" aria-label="Password" />
                </div>
                <div className="flex flex-col space-y-2">

                    <Button 
                        type="submit"
                        variant="outline" 
                        className="w-full h-12 cursor-pointer"
                    >
                        Login
                    </Button>

                    <Button 
                    onClick={() => router.push("/recovery")}
                    type="button"
                    variant="link" 
                    className="text-muted-foreground cursor-pointer">
                        Forgot your password?
                    </Button>
                    
                </div>
            </form>
            <footer className="py-6 text-center text-sm text-muted-foreground">
                <p>© 2026 Hermes Urban Logistics. Todos os direitos reservados.</p>
            </footer>
        </div>
    )
}
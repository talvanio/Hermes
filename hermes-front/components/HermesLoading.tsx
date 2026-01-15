import hermesImg from "@/assets/hermesgif.gif";
import Image from 'next/image'

export default function HermesLoading() {
    return (
        <div style={{ height: '100vh', width: '100vw', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <Image 
                src={hermesImg.src}
                alt="Loading Hermes"
                width={300}
                height={300}
                style={{ opacity: 0.2 }}
            />
      </div>
    )
}